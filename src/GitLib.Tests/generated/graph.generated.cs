//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;

namespace GitLib.Tests
{
    public partial class GraphTests : GitLibTestsBase
    {
        public GraphTests() : base("graph") {}
        
        private void Check()
        {
            Test_git_graph_ahead_behind();
            Test_git_graph_descendant_of();
        }
    }
}
