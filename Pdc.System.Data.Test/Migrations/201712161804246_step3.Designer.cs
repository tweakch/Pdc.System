
using System.CodeDom.Compiler;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Resources;

namespace Pdc.System.Data.Test.Migrations
{
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class step3 : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(step3));
        
        string IMigrationMetadata.Id
        {
            get { return "201712161804246_step3"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
