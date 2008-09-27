using System;
using System.Collections.Generic;

namespace Machine.UoW
{
  public class UnitOfWorkFactory : IUnitOfWorkFactory
  {
    private readonly IUnitOfWorkManagement _unitOfWorkManagement;

    public UnitOfWorkFactory(IUnitOfWorkManagement unitOfWorkManagement)
    {
      _unitOfWorkManagement = unitOfWorkManagement;
    }

    public IUnitOfWork StartUnitOfWork()
    {
      return new UnitOfWork(_unitOfWorkManagement);
    }
  }
}
