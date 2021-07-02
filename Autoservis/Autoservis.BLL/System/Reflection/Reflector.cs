﻿using System.Linq.Expressions;

namespace System.Reflection
{
  public static class Reflector
  {
    public static string GetPropertyName<T>(Expression<Func<T, object>> expression)
    {
      return GetProperty<T>(expression).Name;
    }

    public static MethodInfo GetStaticMethod(Expression<Action> expression)
    {
      var methodCall = expression.Body as MethodCallExpression;
      if (methodCall == null)
      {
                // throw new ArgumentException(AutoservisBLL.BLL.Properties.Resource.MethodCallExpected);
                throw new Exception("BLA");
      }
      return methodCall.Method;
    }

    public static MethodInfo GetMethod<T>(Expression<Action<T>> expression)
    {
      var methodCall = expression.Body as MethodCallExpression;
      if (methodCall == null)
      {
                // throw new ArgumentException(AutoservisBLL.Properties.Resources.MethodCallExpected);
                throw new Exception("BLA");
            }
      return methodCall.Method;
    }

    public static PropertyInfo GetProperty<T>(Expression<Func<T, object>> expression)
    {
      MemberExpression memberExpression;

      var unary = expression.Body as UnaryExpression;
      if (unary != null)
      {
        memberExpression = unary.Operand as MemberExpression;
      }
      else
      {
        memberExpression = expression.Body as MemberExpression;
      }

      if (memberExpression == null || !(memberExpression.Member is PropertyInfo))
      {
                //throw new ArgumentException(AutoservisBLL.Properties.Resources.PropertyExpected);
                throw new Exception("BLA");
            }
      return (PropertyInfo)memberExpression.Member;
    }
  }
}
