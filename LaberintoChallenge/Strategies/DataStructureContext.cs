
using Challenge.Entities;

namespace Challenge.Strategies
{
    public class DataStructureContext
    {
        private IDataStructureStrategy _dataStructure;

        public IDataStructureStrategy DataStructure
        {
            set { _dataStructure = value; }
            get { return _dataStructure; }
        }

        public DataStructureContext(IDataStructureStrategy dataStructure)
        {
            _dataStructure = dataStructure;
        }

        public List<Position> CalculateShortestPath()
        {
            return _dataStructure.CalculateShortestPath();
        }
    }
}
