using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class SubclassSelectorAttribute : PropertyAttribute
{
    bool m_includeMono;

    Type m_type;

    public SubclassSelectorAttribute(bool includeMono = false, Type type = null)
    {
        m_includeMono = includeMono;
        m_type = type;
    }

    public bool IsIncludeMono()
    {
        return m_includeMono;
    }

    public Type Type() => m_type;
}