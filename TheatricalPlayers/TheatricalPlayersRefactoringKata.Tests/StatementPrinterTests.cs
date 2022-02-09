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
           Invoice invoice = new Invoice("BigCo", new List<Performance>{new Performance(new Play("Hamlet", "tragedy"), 55),
                new Performance(new Play("As You Like It", "comedy"), 35),
                new Performance(new Play("Othello", "tragedy"), 40)});
            
            StatementPrinter statementPrinter = new StatementPrinter();
            var result = statementPrinter.Print(invoice);

            Approvals.Verify(result);
        }
        [Fact]
        public void test_statement_with_new_play_types()
        {          
            Invoice invoice = new Invoice("BigCoII", new List<Performance>{new Performance(new Play("Henry V", "history"), 53),
                new Performance(new Play("As You Like It", "pastoral"), 55)});
            
            StatementPrinter statementPrinter = new StatementPrinter();

            Assert.Throws<Exception>(() => statementPrinter.Print(invoice));
        }
    }
}
