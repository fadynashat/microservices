
using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;
using System;
using Xunit;

public class EmployeeAggregateTest
{
    public EmployeeAggregateTest()
    { }

    [Fact]
    public void Create_employee_item_success()
    {

        //Arrange  
        var _random = new Random();
        var identity = _random.Next(1, 10000000);

        var name = "fady";
        var address = new Address("el-shorta street", "assuit", "egypt");
        //Act 
        var fakeEmployeeItem = new Employe(identity, name,address,"01208844875");

        //Assert
        Assert.NotNull(fakeEmployeeItem);
    }

 
}