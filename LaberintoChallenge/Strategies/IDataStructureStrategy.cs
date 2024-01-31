using Challenge.Entities;

namespace Challenge.Strategies
{
    public interface IDataStructureStrategy
    {
        public List<Position> CalculateShortestPath();
    }
}
