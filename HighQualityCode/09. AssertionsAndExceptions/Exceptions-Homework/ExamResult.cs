﻿using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get 
        { 
            return this.grade; 
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Grade must be positive number");
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get 
        { 
            return this.minGrade; 
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Min grade must be positive number");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get 
        { 
            return this.maxGrade; 
        }
        private set
        {
            if (value <= this.maxGrade)
            {
                throw new ArgumentOutOfRangeException("Max grade must be positive number");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get 
        { 
            return this.comments; 
        }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Commnent must have almoust one charackter.");
            }

            this.comments = value;
        }
    }
}