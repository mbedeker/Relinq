using System.Linq.Expressions;
using NUnit.Framework;
using Remotion.Data.Linq.Clauses;
using Remotion.Data.Linq.DataObjectModel;
using Remotion.Data.Linq.Parsing.Details.WhereConditionParsing;

namespace Remotion.Data.Linq.UnitTests.ParsingTest.DetailsTest.WhereConditionParsingTest
{
  [TestFixture]
  public class BinaryExpressionParserTest
  {
    [Test]
    public void ParseAnd ()
    {
      WhereClause whereClause = ExpressionHelper.CreateWhereClause ();
      BinaryExpression binaryExpression = Expression.And (Expression.Constant (5), Expression.Constant (5));
      ICriterion criterion = new Constant (5);
      BinaryExpressionParser parser = new BinaryExpressionParser (whereClause, delegate (Expression expression)
      {
        Expression.Constant (5);
        return criterion;
      });
      
      ICriterion actualCriterion = parser.Parse (binaryExpression);

      ICriterion expectedCriterion = new ComplexCriterion (new Constant (5), new Constant (5), ComplexCriterion.JunctionKind.And);
      
      Assert.AreEqual (expectedCriterion, actualCriterion);
    }

    [Test]
    public void ParseOr ()
    {
      WhereClause whereClause = ExpressionHelper.CreateWhereClause ();
      BinaryExpression binaryExpression = Expression.Or (Expression.Constant (5), Expression.Constant (5));
      ICriterion criterion = new Constant (5);
      BinaryExpressionParser parser = new BinaryExpressionParser (whereClause, delegate (Expression expression)
      {
        Expression.Constant (5);
        return criterion;
      });
      ICriterion actualCriterion = parser.Parse (binaryExpression);
      ICriterion expectedCriterion = new ComplexCriterion (new Constant (5), new Constant (5), ComplexCriterion.JunctionKind.Or);
      Assert.AreEqual (expectedCriterion, actualCriterion);
    }

    [Test]
    public void ParseEqual ()
    {
      WhereClause whereClause = ExpressionHelper.CreateWhereClause ();
      BinaryExpression binaryExpression = Expression.Equal (Expression.Constant (5), Expression.Constant (5));
      ICriterion criterion = new Constant (5);
      BinaryExpressionParser parser = new BinaryExpressionParser (whereClause, delegate (Expression expression)
      {
        Expression.Constant (5);
        return criterion;
      });
      ICriterion actualCriterion = parser.Parse (binaryExpression);
      ICriterion expectedCriterion = new BinaryCondition (new Constant (5), new Constant (5), BinaryCondition.ConditionKind.Equal);
      Assert.AreEqual (expectedCriterion, actualCriterion);
    }

    [Test]
    public void ParseGreaterThan ()
    {
      WhereClause whereClause = ExpressionHelper.CreateWhereClause ();
      BinaryExpression binaryExpression = Expression.GreaterThan (Expression.Constant (5), Expression.Constant (5));
      ICriterion criterion = new Constant (5);
      BinaryExpressionParser parser = new BinaryExpressionParser (whereClause, delegate (Expression expression)
      {
        Expression.Constant (5);
        return criterion;
      });
      ICriterion actualCriterion = parser.Parse (binaryExpression);
      ICriterion expectedCriterion = new BinaryCondition (new Constant (5), new Constant (5), BinaryCondition.ConditionKind.GreaterThan);
      Assert.AreEqual (expectedCriterion, actualCriterion);
    }

    [Test]
    public void ParseLessThan ()
    {
      WhereClause whereClause = ExpressionHelper.CreateWhereClause ();
      BinaryExpression binaryExpression = Expression.LessThan (Expression.Constant (5), Expression.Constant (5));
      ICriterion criterion = new Constant (5);
      BinaryExpressionParser parser = new BinaryExpressionParser (whereClause, delegate (Expression expression)
      {
        Expression.Constant (5);
        return criterion;
      });
      ICriterion actualCriterion = parser.Parse (binaryExpression);
      ICriterion expectedCriterion = new BinaryCondition (new Constant (5), new Constant (5), BinaryCondition.ConditionKind.LessThan);
      Assert.AreEqual (expectedCriterion, actualCriterion);
    }
  }
}