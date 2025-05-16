namespace FlightProject.Helper
{
	public class Pagination<T>
	{
		public Pagination(int pageSize, int pageIndex, IEnumerable<T> data, int count)
		{
			PageSize = pageSize;
			PageIndex = pageIndex;
			Data = data;
			Count = count;
		}
		public Pagination()
		{
			
		}
		public int PageSize { get; set; }
		public int PageIndex { get; set; }
		public int Count { get; set; }
		public IEnumerable<T> Data { get; set; }
	}
}
