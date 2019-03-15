using System;
using System.Collections.Generic;
using System.Text;


//#region Additional Namespaces
    //using System.Data.Entity
    //this is for the EntityFrameword ADO.Net stuff

    //using NorthwindSystem.Data
    //this is for the <T> definitions
//#endregion

    //this class needs to have access to ADO.Net in EntityFramework
    //the NuGet package Manager will have the EntityFramework, install it please
    //this project needs the assembly System.Data.Entity
    //this project needs a reference to your .Data project
    //this project needs to use the following namespaces:
    //  a)System.Data.Entity
    //  b).Data project namespace
namespace NorthwindSystem.DAL
{
    //the class access is restricted to requests from within the library the class exists in: internal

        //the class inherits (ties into EntityFramework) the class DbContext
        //for inherits, add a colon after the class name and then add the other part such as DbContext

    internal class NorthwindContext//:DbContext
    {
        //add the System.Data.Entity reference

        //setup your class default constructor to supply
        //  your connection string name to the DbContext class
        //  inherited (base) class

        //public NorthwindContext():base("NWDB")
        //{}

        //create an EntityFramework DbSet<T> for each
        //  mapped sql table
        // <T> is your class in the .Data project
        //this is a property
        //public DbSet<Product> Products{get; set;}
    }
}
