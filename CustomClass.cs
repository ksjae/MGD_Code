using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


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
    public Task() {}
    public Task(string taskName, TaskType taskType, int pointsRequired) {
        this.done = 0;
        this.required = pointsRequired;
        this.name = taskName;
        this.type = taskType;
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

public class GameProject: Item {
    
}

[System.Serializable]
public class Company: Item
{
    public int asset=0, cash=0;
    public Company(){}
    public Company(string name, int startCash, string desc="None"): base(name, desc){
        this.cash = startCash;
    }
}
