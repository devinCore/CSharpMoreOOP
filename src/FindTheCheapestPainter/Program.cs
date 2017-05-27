using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheCheapestPainter
{
    class Program
    {
        //Normal Approach
        //Requirement: Find an available painter and pick the cheapest one.
        //Conclusion: This is truly a bad piece of code
        //1. It is hard to understand.
        //2. There is a gap between the requirement and the implementation.
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            double bestPrice = 0;
            IPainter cheapest = null;

            foreach (IPainter painter in painters)
            {
                if (painter.IsAvailable)
                {
                    double price = painter.EstimateCompensation(sqMeters);
                    if (cheapest == null || price < bestPrice)
                    {
                        cheapest = painter;
                    }
                }
            }
            return cheapest;
        }

        //Charles Approach
        private static IPainter FindCheapestPainter2(double sqMeters, IEnumerable<IPainter> painters)
        {
            if (!painters.Any(p => p.IsAvailable))
                return null;

            return painters.Where()
        }

        //Course Implementation
        //Mind Experiment with Desired Implementation
        //Sequence of steps where bug is reported.
        //1. Is the sequence of painters empty?
        //2. Are all painters unavailable?
        //3. If that has nothing to do with the bug, then the bug is else where? 
        private static IPainter FindCheapestPainter3
            (double sqMeters, IEnumerable<IPainter> painters)
        {
            //return
            //    painters
            //        .Where(p => p.IsAvailable)
            //        .FirstOrDefault(painters.Min(p => p.EstimateCompensation(sqMeters)));
            //.Select(p => p..Min(p => p.EstimateCompensation(sqMeters));

            //1st implementation: Sorting. <- BAD IDEA; Yields 0(NlogN) running time
            return
                painters
                    .Where(painter => painter.IsAvailable)
                    .OrderBy(painter => painter.EstimateCompensation(sqMeters))
                    .FirstOrDefault();

            //2nd implementation: Picking. <- BETTER IDEA; Sorting is bad, as we only want to
            //pick the one element. We expect a solution with O(N) running time.
            //Problems with this implementation: 
            //1. EstimateCompensation is executed twice per iteration.
            //2. Cant return null. What if the sequence is empty.
            //3. Harder to read. Poor readability
            return
              painters
                  .Where(painter => painter.IsAvailable)
                  .Aggregate((best, cur) =>
                    best.EstimateCompensation(sqMeters) < cur.EstimateCompensation(sqMeters) ?
                    best : cur);

            //To solve problem #2.
            return
              painters
                  .Where(painter => painter.IsAvailable)
                  .Aggregate((IPainter)null, (best, cur) =>
                    best == null ||
                    best.EstimateCompensation(sqMeters) < cur.EstimateCompensation(sqMeters) ?
                    best : cur);
            //this time it takes null as the first element.

            //how the above function works.
            //Aggreagate(Func<IPainter, IPainter, IPainter>) <- means that it takes 2 IPainter parameters and returns IPainter.
            //The first element as the best fit or the 'Aggregate', the first argument, then the current element of the sequence as the second argument.
            //when all the elements of the sequence is exhausted/iterated, the aggregate is return as the result.

            //3rd implementation: applying extension methods to hide away the complexity.
            return
               painters
                 .Where(painter => painter.IsAvailable)
                 .WithMinimum(painter => painter.EstimateCompensation(sqMeters));

        }

        private static IPainter FindFastestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailable)
                    .WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));
        }

        private static IPainter WorkTogether(double sqMeters, IEnumerable<IPainter> painters)
        {
            TimeSpan time =
                TimeSpan.FromHours(
                    1 / painters
                            .Where(painter => painter.IsAvailable)
                            .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
                            .Sum()
                    );

            double cost =
                   1 / painters
                           .Where(painter => painter.IsAvailable)
                           .Select(painter => 
                                painter.EstimateCompensation(sqMeters) /
                                painter.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours)
                           .Sum();

            return new ProportionalPainter()
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours/sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        } 


        
        static void Main(string[] args)
        {
            IEnumerable<ProportionalPainter> painters = new ProportionalPainter[10];

            var painter = CompositePainterFactories.CreateGroup(painters);

        }

        //The OOP Way --> transferred to CompositePainterFactories
        //private static IPainter FindCheapestPainter(double sqMeters, Painters painters) =>
        //    painters.GetAvailable().GetCheapestPainter(sqMeters);

        //private static IPainter FindFastestPainter(double sqMeters, Painters painters) =>
        //    painters.GetAvailable().GetFastestPainter(sqMeters);

    }
}
