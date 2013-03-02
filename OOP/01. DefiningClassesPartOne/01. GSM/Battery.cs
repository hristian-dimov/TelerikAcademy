using System;

enum BatteryType { LiIon, NiMH, NiCd };

class Battery
{
    private BatteryType batteryTypeModel;
    private string model;
    private double? idleTime;
    private double? talkTime;

    public Battery()
    {
    }

    public Battery(BatteryType batteryTypeModel)
        : this(batteryTypeModel, null, null, null)
    {
    }

    public Battery(BatteryType batteryTypeModel, string model)
        : this(batteryTypeModel, model, null, null)
    {
    }

    public Battery(BatteryType batteryTypeModel, string model, double? idleTime)
        : this(batteryTypeModel, model, idleTime, null)
    {
    }

    public Battery(BatteryType batteryTypeModel, string model, double? idleTime, double? talkTime)
    {
        this.BatteryTypeModel = batteryTypeModel;
        this.Model = model;
        this.IdleTime = idleTime;
        this.TalkTime = talkTime;
    }

    public BatteryType BatteryTypeModel
    {
        get { return this.batteryTypeModel; }
        set { this.batteryTypeModel = value; }
    }

    public string Model
    {
        get { return this.model; }
        set
        {
            if (value == null || value.Length > 2)
            {
                this.model = value;
            }
            else
            {
                throw new ArgumentException("The battery model should be longer than two characters");
            }
        }
    }

    public double? IdleTime
    {
        get { return this.idleTime; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The idle hours should be a positive number");
            }
            else
            {
                this.idleTime = value;
            }
        }
    }

    public double? TalkTime
    {
        get { return this.talkTime; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The talk hours should be a positive number");
            }
            else
            {
                this.talkTime = value;
            }
        }
    }

    public override string ToString()
    {
        return string.Format("[ Model: {0} ], [ Type: {1} ], [ Hours Idle: {2} ], [ Hours Talk: {3} ]",
            this.Model, this.BatteryTypeModel, this.IdleTime, this.TalkTime);
    }
}