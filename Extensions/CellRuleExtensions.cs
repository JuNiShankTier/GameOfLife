using GameOfLife.Models;

namespace GameOfLife.Extensions
{
    public static class CellRuleExtensions
    {
        public static Cell RuleOfSolitude(this Cell cell, int livingNeighbours)
        {
            if (cell.IsAlive() && livingNeighbours < 2)
            {
                cell.Die();
            }
            return cell;
        }

        public static Cell RuleOfOverpopulation(this Cell cell, int livingNeighbours)
        {
            if (cell.IsAlive() && livingNeighbours > 3)
            {
                cell.Die();
            }
            return cell;
        }

        public static Cell RuleOfSurvivor(this Cell cell, int livingNeighbours)
        {
            /* Rule implementation is not needed because rule does not effect anything
             * Exists only for the sake of completeness
            if (cell.IsAlive() && (livingNeighbours == 2 || livingNeighbours == 3))
            {
                return cell;
            }
            */
            return cell;
        }

        public static Cell RuleOfCreation(this Cell cell, int livingNeighbours)
        {
            if (!cell.IsAlive() && livingNeighbours == 3)
            {
                cell.Birth();
            }
            return cell;
        }
    }
}
