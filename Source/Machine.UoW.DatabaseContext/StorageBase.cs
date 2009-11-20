using System;
using System.Data;

namespace Machine.UoW.DatabaseContext
{
  public abstract class StorageBase<T> : IContextStorage<T> where T : class
  {
    protected abstract T InternalValue { get; set; }

    public T StoredValue
    {
      get
      {
        if (InternalValue == null)
        {
          throw new NoStoredValueException("There is no " + typeof(T) + " available!");
        }
        return InternalValue;
      }
      set
      {
        if (InternalValue != value)
        {
          if (InternalValue != null && value != null)
          {
            throw new InvalidOperationException("Trying to use another " + typeof(T) + " when one is already in use!");
          }
        }
        InternalValue = value;
      }
    }

    public bool HasValue
    {
      get { return InternalValue != null; }
    }
  }
}