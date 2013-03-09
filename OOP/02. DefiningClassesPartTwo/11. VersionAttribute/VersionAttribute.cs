﻿using System;

[AttributeUsage(
AttributeTargets.Struct |
AttributeTargets.Class |
AttributeTargets.Interface |
AttributeTargets.Method |
AttributeTargets.Enum
)]

class VersionAttribute : System.Attribute
{
    public string Version { get; private set; }

    public VersionAttribute(string version)
    {
        this.Version = version;
    }
}