using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class StatementPrinterTests
    {
        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void test_statement_exemple()
        {
           Invoice invoice = new Invoice("BigCo", new List<Performance>{new Performance(new PlayTragedy("Hamlet"), 55),
                new Performance(new PlayComedy("As You Like It"), 35),
                new Performance(new PlayTragedy("Othello"), 40)});
            
            StatementPrinter statementPrinter = new StatementPrinter();
            var result = statementPrinter.Print(invoice);

            Approvals.Verify(result);
        }
    }
}
