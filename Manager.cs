using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private Company company;
    public Company Company { get{ return company; }}

    private int[] _revenueHistory={34632,34765,31857,98121,21634,21389,21347,56432,23476,76584,12347,87652}; //revenueHistory[0] = this mo. rev. => revHis[cnt] = rev. cnt (weeks/etc.) before
    public int[] RevenueHistory(int unit=6){
        return _revenueHistory.Take(unit).ToArray();
    }

    private int[] _followerHistory={51245,12347,65123,12635,65431,12354,55374,33521,57374,12762,78472,67312}; //works just like revenueHistory
    public int[] FollowerHistory(int unit=6){
        return _followerHistory.Take(unit).ToArray();
    }

    private DateTime _date = new DateTime(1970,1,1);
    public DateTime Date {
        get => _date;
    }
    public void PassDay(int days=1){
        TimeSpan duration = new TimeSpan(days, 0, 0, 0);
        _date.Add(duration);
    }

    void Start(){
        int startCash=100000;
        this.company = new Company("다국어 IMETEST", startCash);
    }
}
