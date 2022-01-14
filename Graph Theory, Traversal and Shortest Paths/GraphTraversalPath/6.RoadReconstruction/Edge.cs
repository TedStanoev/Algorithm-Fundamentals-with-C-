namespace _6.RoadReconstruction
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public override string ToString()
            => $"{this.First} {this.Second}";
    }
}
