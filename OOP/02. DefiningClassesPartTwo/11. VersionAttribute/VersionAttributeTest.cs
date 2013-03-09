using System;

[VersionAttribute("1.0 ( final )")]
class VersionAttributeTest
{
    static void Main()
    {
        object[] allAttributes = typeof(VersionAttributeTest).GetCustomAttributes(false);
        
        foreach (VersionAttribute attr in allAttributes)
        {
            Console.WriteLine("This class version is {0}. ", attr.Version);
        }
    }
}