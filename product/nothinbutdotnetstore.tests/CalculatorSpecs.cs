using System.Data;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests
{
    public class CalculatorSpecs
    {
        public abstract class concern : observations_for_a_sut_without_a_contract<Calculator>
        {
        }

        [Concern(typeof (Calculator))]
        public class when_adding_two_numbers_together : concern
        {
            context c = () =>
            {
                provide_a_basic_sut_constructor_argument(2);
                provide_a_basic_sut_constructor_argument("hello");
                connection = the_dependency<IDbConnection>();
                command = an<IDbCommand>();

                connection.Stub(x => x.CreateCommand()).Return(command);
            };

            because b = () =>
            {
                result = sut.add(1, 3);
            };


            it should_open_a_connection_to_the_database = () =>
            {
                connection.received(x => x.Open());
            };

            it should_create_a_command_to_run_a_query = () =>
            {
                command.received(x => x.ExecuteNonQuery());
            };

            it should_return_the_sum = () =>
            {
                result.should_be_equal_to(4);
            };

            static int result;
            static IDbConnection connection;
            static IDbCommand command;
        }
    }

    public class Calculator
    {
        int number;
        IDbConnection connection;
        string another;

        public Calculator(string another, int number, IDbConnection connection)
        {
            this.number = number;
            this.connection = connection;
            this.another = another;
        }

        public int add(int first_number, int second_number)
        {
            using (connection)
            using (var command = connection.CreateCommand())
            {
                connection.Open();
               command.ExecuteNonQuery();
            }

            return first_number + second_number;
        }
    }
}