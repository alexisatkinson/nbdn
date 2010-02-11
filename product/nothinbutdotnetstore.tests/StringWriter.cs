using System.IO;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;

namespace nothinbutdotnetstore.tests
{
    public class ConsoleWriterSpec
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<StringWriter, DefaultStringWriter>
        {
        }

        [Concern(typeof (DefaultStringWriter))]
        public class when_input_is_provided : concern
        {
            context c = () =>
            {
                text_writer = the_dependency<System.IO.TextWriter>();
            };

            because b = () =>
            {
                sut.Write("Foo");
            };


            it first_observation = () =>
            {
                text_writer.received(x => x.Write("Foo"));
            };

            static System.IO.TextWriter text_writer;
        }
    }

    public class DefaultStringWriter : StringWriter
    {
        System.IO.TextWriter writer;

        public DefaultStringWriter(System.IO.TextWriter writer)
        {
            this.writer = writer;
        }

        public void Write(string text)
        {
            writer.Write(text);
        }
    }

    public interface StringWriter
    {
        void Write(string text);
    }
}