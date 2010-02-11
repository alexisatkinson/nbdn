 using System;
 using System.Data;
 using System.Security;
 using System.Security.Principal;
 using System.Threading;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.core.commands;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdd.mocking.rhino;
 using developwithpassion.bdddoc.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests
{
    public class CalculatorSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ICalculator, Calculator>
        {

        }

        [Concern(typeof (Calculator))]
        public class when_two_numbers_are_added_together : concern
        {
            context c = () =>
            {
                provide_a_basic_sut_constructor_argument(2);
                connection = the_dependency<IDbConnection>(); //stores that mock instance in a dictionary used to creat the sut
                command = an<IDbCommand>(); //just a plain old mock that has nothing to do with sut construction
                my_principal = an<IPrincipal>();
                my_principal.Stub(x => x.IsInRole("blah")).Return(true);

                connection.Stub(x => x.CreateCommand()).Return(command);
            };

            after_the_sut_has_been_created ac = () =>
            {
                sut.do_something();
            } ;

            because b = () =>
            {
                result = sut.add(1, 3);
            };

            it should_open_a_connections_to_the_database = () =>
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
            static int initial_number;
            static IDbConnection connection;
            static IDbCommand command;
            static IPrincipal my_principal;
        }

        [Concern(typeof(Calculator))]
        public class is_the_user_in_the_blah_role : concern
        {
            context c = () =>
            {
                provide_a_basic_sut_constructor_argument(2);
                my_principal = an<IPrincipal>();
                my_principal.Stub(x => x.IsInRole("blah")).Return(true);
                change(() => Thread.CurrentPrincipal).to((my_principal));
            };

            after_the_sut_has_been_created ac = () =>
            {
                sut.do_something();
            };

            because b = () =>
            {
                doing(() => sut.add(1, 3));
            };

            it should_throw_a_security_exception = () =>
            {
                exception_thrown_by_the_sut.should_be_an_instance_of<SecurityException>();
            };


            static int result;
            static int initial_number;
            static IPrincipal my_principal;
        }
    }

    public interface ICalculator
    {
        int add(int first_number, int second_number);
        void do_something();
    }

    public class Calculator : ICalculator
    {
        int number;
        IDbConnection connection;

        public Calculator(int number, IDbConnection connection)
        {
            this.number = number;
            this.connection = connection;
        }

        public int add(int first_number, int second_number)
        {
            if(Thread.CurrentPrincipal.IsInRole("blah")) throw new SecurityException("You are not smart enough to use this code!");
            using (connection)
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            connection.Open();
            return first_number + second_number;
        }

        public void do_something()
        {
            

        }
    }
}
