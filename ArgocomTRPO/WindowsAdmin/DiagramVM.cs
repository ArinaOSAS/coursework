using System;
using System.Collections.ObjectModel;
using System.Linq;
using ArgocomTRPO.DB;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

namespace ArgocomTRPO.WindowsAdmin;

public class DiagramVM : ObservableObject
{
    public static DateOnly? fromDate { get; set; }
    public static DateOnly? toDate { get; set; }
     
    
    double count = ResourceManager.trpoKyrsoContext.Breakings.Count();
    public ISeries[] Series { get; set; } =
    {
        
        new ColumnSeries<DateTimePoint>
        {
            TooltipLabelFormatter = (chartPoint) =>
                $"{new DateTime((long)chartPoint.SecondaryValue):dd.MM.yyyy}: {chartPoint.PrimaryValue}",
            Values = new ObservableCollection<DateTimePoint>
            (
                
                // notice we are missing the day new DateTime(2021, 1, 2)

                ResourceManager.trpoKyrsoContext.Breakings.ToList().Where(q => q.Datebreaking >= fromDate && q.Datebreaking <= toDate)
                    .Select(q => new DateTimePoint(q.Datebreaking.ToDateTime(new TimeOnly(0)), ResourceManager.trpoKyrsoContext.Breakings.Where(a => a.Datebreaking == q.Datebreaking).Count()) ).ToList()
                
            )
        }
    };
    
    public Axis[] XAxes { get; set; } =
    {
        new Axis
        {
            Labeler = value => new DateTime((long) value).ToString("dd.MM.yyyy"),
            LabelsRotation = 80,
            UnitWidth = TimeSpan.FromDays(1).Ticks,
            MinStep = TimeSpan.FromDays(1).Ticks 
        }
    };
}