using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class Item {
    private static int currentID;

    protected int ID {get; set; }
    public string Name {get; set;}
    public string Description {get; set;}

    public Item() {}

    public Item(string title, string desc="") {
        ID = GetNextID();
        Name = title;
        Description = desc;
    }

    // Static constructor to initialize the static member, currentID. This
    // constructor is called one time, automatically, before any instance
    // of WorkItem or ChangeRequest is created, or currentID is referenced.
    static Item() => currentID = 0;
    protected int GetNextID() => ++currentID;

    public static float RandomGaussian(float minValue = 0.0f, float maxValue = 1.0f)
    {
        float u, v, S;

        do
        {
            u = 2.0f * UnityEngine.Random.value - 1.0f;
            v = 2.0f * UnityEngine.Random.value - 1.0f;
            S = u * u + v * v;
        }
        while (S >= 1.0f);

        // Standard Normal Distribution
        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);

        // Normal Distribution centered between the min and max value
        // and clamped following the "three-sigma rule"
        float mean = (minValue + maxValue) / 2.0f;
        float sigma = (maxValue - mean) / 3.0f;
        return Mathf.Clamp(std * sigma + mean, minValue, maxValue);
    }

}



public enum TaskType {
    Design,
    Code,
    Graphic,
    Audio
}

public class Task {
    protected int required {get; set;}
    protected int done {get;set;}
    protected string name {get;set;}
    public int cost{get;set;}
    public TaskType type;
    public double progress {
        get { return done/required * 100; }
        set {
            if (value < 0)
                done = 0;
            else
                done = (int)(required * value / 100);
        }
    }
    public bool isCompleted{
        get {return (done >= required);}
    }
    public Task() {}
    public Task(string taskName, TaskType taskType, int pointsRequired, int cost) {
        this.done = 0;
        this.required = pointsRequired;
        this.name = taskName;
        this.type = taskType;
        this.cost = cost;
    }
}

public class WorkPoint
{
    public float[] point = new float[System.Enum.GetNames(typeof(TaskType)).Length];
    public WorkPoint(float gameDesign=0, float code=0, float graphic=0, float audio=0){
        this.point[(int)TaskType.Design] = gameDesign;
        this.point[(int)TaskType.Code] = code;
        this.point[(int)TaskType.Graphic] = graphic;
        this.point[(int)TaskType.Audio] = audio;
    }
}



public class Employee: Item {

    public WorkPoint workPoint;
    public int burnout=0;
    public Employee(){}
    public Employee(TaskType mainPerf, int mainPerfGoal=10, int subPerfGoal=5) {
        this.Name = "Name TBA";
        this.ID = GetNextID();
        this.Description = "";
        /*
        int[] p = {}
        this.performance = 
        */
    }
    
    
}

public class Team {
    public Task currentTask{get; set;}
    private Employee[] _employeeList;
    public void AddEmployee(int id){

    }
    public void RemoveEmployee(int id){

    }
    public int efficiency {
        get {
            return (int)_employeeList.Average(person => person.burnout);
        }
    }
    public void Boost(int negativeBurnout){  //Reduce burnout by negativeBurnout
        for (int i=0;i<_employeeList.Length;i++){
            _employeeList[i].burnout-=negativeBurnout;
            if (_employeeList[i].burnout < 0){
                _employeeList[i].burnout = 0;
            }
        }
    }
    public float performance() {
        return 1.0f;
    }
    
    public void ProcessDayTask(){
        
    }
}

public class GameConfig {

}

/***

What consists of GameProject: A top-down approach

- Tasks make a game
    * There are 'required' tasks and 'optional' tasks.
    * Required tasks are ADDED ON CREATION (pervent DBZ)

- After development completion, game is first evaluated.
    * "Professional" evaluation score
    * People's expectation from game (user satisfaction)

- And it will sell.
    * Units sold & earnings
    * call func. to sell for a unit of time
    * after retrieved from shelf, marked 'not selling'

***/

public class GameProject: Item {
    private int design, bug, qa; //design,qa equals actual percentage
    private GameConfig config;
    private int _unitSales, _sales;
    public void makeSale(int unit, int price){
        _unitSales += unit;
        _sales += unit*price;
    }
    private int evalPts, satisfactionPts;
    private int[] _points = {0,0,0,0,0,0,0,0,0,0,0,0};
    public int pointsByType(TaskType taskType){
        return _points[(int)taskType];
    }
    public void AddPoints(int[] points){
        for(int i=0;i<points.Length;i++){
            _points[i] += points[i];
        }
    }
    public void AddPoint(int point, TaskType taskType){
        _points[(int)taskType] += point;
    }
    public bool isFinished(){
        foreach(Task t in Tasks){
            if (!t.isCompleted){
                return false;
            }
        }
        return true;
    }
    public List<Task> Tasks = new List<Task>();
    public int CancelTask(Task t){ //returns cashback from canceled task
        Tasks.Remove(t);
        return (int)(t.cost * (1-t.progress));
    }
    public List<Task> pendingTasks{
        get { return Tasks.FindAll(task => task.isCompleted == false);}
    }
    //TODO: Implement proper design/qa scoring metric via Task scanning
    public int designStat(){
        return design;
    }
    public int codeStat(){
        return bug;
    }
    public int qaStat(){
        return qa;
    }
    public GameProject(){}
    public GameProject(string name, string desc, GameConfig gameConfig): base(name, desc){
        config = gameConfig;
        Tasks.Add(new Task("Basic Design",TaskType.Design,10,0));
        Tasks.Add(new Task("Copy-paste SO",TaskType.Code,10,0));
        Tasks.Add(new Task("Pirate sprite",TaskType.Graphic,10,0));
        Tasks.Add(new Task("Unlicensed audio",TaskType.Audio,10,0));
    }
}

[System.Serializable]
public class Company: Item
{
    public int asset=0, cash=0;
    private Employee[] unplaced;
    private Team[] teams;
    public Company(){}
    public Company(string name, int startCash, string desc="None"): base(name, desc){
        this.cash = startCash;
    }
    private List<GameProject> _gameProj = new List<GameProject>();
    public List<GameProject> GamesInMaking(bool showAll=false){
        var queryResult = new List<GameProject>();
        foreach(GameProject proj in _gameProj){
            if (!proj.isFinished()){
                queryResult.Add(proj);
            }
        }
        return queryResult;
    }
    public List<GameProject> GameProjects(){
        return _gameProj;
    }
    public UnityEvent GameProjectModified;
    public void MakeProject(GameProject proj){
        _gameProj.Add(proj);
    }
    public void ScrapProject(GameProject proj){
        //cancel all task
        foreach (Task pending in proj.pendingTasks){
            cash += proj.CancelTask(pending);
        }
        _gameProj.Remove(proj);
    }
    public void Work(){
        foreach(TaskType taskType in Enum.GetValues(typeof(TaskType))){
            
        }
    }
    public float satisfaction{
        get {
            return 0.8f;
        }
    }
    public float rating{
        get {
            return 0.61f;
        }
    }
}
