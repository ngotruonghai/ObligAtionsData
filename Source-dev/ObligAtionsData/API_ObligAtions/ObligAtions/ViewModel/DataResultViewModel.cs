namespace ObligAtions.ViewModel
{
    public class DataResultViewModel<T>
    {
        public int StatusCode { get; set; }
        public string? Description { get; set; }
        public object Data { get; set; }
    }
}
