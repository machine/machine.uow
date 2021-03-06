using System;
using NHibernate;

namespace Machine.UoW.NHibernate
{
  public class TransientSessionManager : ISessionManager
  {
    readonly ISessionFactory _sessionFactory;

    public TransientSessionManager(ISessionFactory sessionFactory)
    {
      _sessionFactory = sessionFactory;
    }

    public IManagedSession OpenSession()
    {
      return new ManagedSession(_sessionFactory.OpenSession(), true);
    }

    public IManagedSession OpenSession(string key)
    {
      return OpenSession();
    }

    public ISession CurrentSession()
    {
      return NH.Session;
    }
  }
}