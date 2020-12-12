using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaRStudy
{
    class Program
    {
        /// <summary>
        /// 客户端调用
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var mediator = new Mediator();
            var colleagueA = new ConcreteColleagueA(mediator);
            var colleagueB = new ConcreteColleagueB(mediator);
            mediator.ColleagueA = colleagueA;
            mediator.ColleagueB = colleagueB;

            colleagueA.SendMessage("你好B，中午一起饭吧？");
            colleagueB.SendMessage("你好A，好的。");

            Console.ReadLine();
        }
    }

    public abstract class AbstractMediator
        {
            public abstract void SendMessage(string msg, AbstractColleague colleague);
        }

        /// <summary>
        /// 抽象同事类
        /// </summary>
        public abstract class AbstractColleague
        {
            public string Name { get; set; }
            protected AbstractMediator Mediator;

            protected AbstractColleague(AbstractMediator mediator)
            {
                Mediator = mediator;
            }

            public abstract void PrintMsg(string msg);
        }

        /// <summary>
        /// 具体中介者，负责同事类之间的交互，他必须清楚的知道需要交互的所有同事类的细节。
        /// </summary>
        public class Mediator : AbstractMediator
        {
            public AbstractColleague ColleagueA;
            public AbstractColleague ColleagueB;

            public override void SendMessage(string msg, AbstractColleague colleague)
            {
                if (colleague == ColleagueA)
                {
                    ColleagueB.PrintMsg(msg);
                }
                else if (colleague == ColleagueB)
                {
                    ColleagueA.PrintMsg(msg);
                }
            }
        }

        /// <summary>
        /// 具体同事类A，他是不知道其他具体同事类的存在的。他与其他同事类的交互，是通过中介者来实现的。
        /// </summary>
        public class ConcreteColleagueA : AbstractColleague
        {
            public ConcreteColleagueA(AbstractMediator mediator) : base(mediator)
            {
            }

            public void SendMessage(string msg)
            {
                Mediator.SendMessage(msg, this);
            }

            public override void PrintMsg(string msg)
            {
                Console.WriteLine($"A收到消息：{msg}");
            }
        }

        public class ConcreteColleagueB : AbstractColleague
        {
            public ConcreteColleagueB(AbstractMediator mediator) : base(mediator)
            {
            }

            public void SendMessage(string msg)
            {
                Mediator.SendMessage(msg, this);
            }

            public override void PrintMsg(string msg)
            {
                Console.WriteLine($"B收到消息：{msg}");
            }
        }

      
    }

