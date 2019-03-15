using System;

namespace NorthwindData
{
    //use an annotation to link this class to the appropriate sql table
    //syntax = [Table("name of sql table")]
    //when Table has an arrow, hover over and click the lightbulb and it'll pull the correct part from the assembly

    //#region Additional Namespaces
    //using System.ComponentModel.DataAnnotation.Schema;
    //using System.ComponentModel.DataAnnotation;
    //#endregion

    //[Table("Products")]


        //annotations are not grouped, they must go with the relevant field
        //assembly needed for DAL class > System.Data.Entity
        //namespaces > System.Data.Entity
        // Data Project

        //from the software, we need to inherit DbContext

        //DbContext needs to know your ConnectionString

        //Data will be referenced by DbSet<T> property, T is our table

    public class Product
    {
        //mapping of the sql table attributes will be to
        //  class properties, one to one relationship



        //the annotation used within the .data project will require the system.componentModel.dataAnnotations assembly
        //this is added through references

        //private string _QuantityPerUnit;
        //use an annotation to identify the primary key
        //1) identity pkey on your sql table(default)
        //  [Key] assumes the identity pkey ending in ID or Id
        //2) a compound pkey on your sql table
        //  [Key, Column(Order = n)] where n is the numeric value
        //  of the physical order of the attribute in the key
        //3) a user supplied pkey on your sql table
        //  [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]


        //key will have an error, hover and pick the dataAnnotation option
        //[Key]
        //public int ProductID{get; set;}
        //public string ProductName {get; set;}
        //public int? SupplierID {get; set;}
        //public int? CategoryID {get ; set}
        //public string QuantityPerUnit{
        //get{ return _QuantityPerUnit;}
        //set {_QuantityPerUnit = string.IsNullOrEmpty(value.Trim())? null:value;}
        //}
        //public decimal? UnitPrice{get; set;}
        //public Int16? UnitsInStock{get; set;}
        //public Int16? UnitsOnOrder{get; set;}
        //public Int16? ReorderLevel{get; set;}
        //public bool Discontinued{get; set;}

        //sample of a computed field on your sql table
        //  to annotate such a property to be taken as a 
        //  sql computed field, use
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public decimal somecomputedsqlfield {get; set;}

        //creating a readonly property that is NOT
        //  an actual field on your sql table
        //  means that NO data is actually transferred

        //example: FirstName and LastName attributes are often
        //  combined into a singular field for display such as:
        //    FullName

        //use the NotMapped annotation for this scenario
        //[NotMapped]
        //public string FullName
        //{ get {return FirstName + " " + LastName;}
        //  }
    }
}
