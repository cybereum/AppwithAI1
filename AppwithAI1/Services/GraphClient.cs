namespace AppwithAI1.Services
{
    internal class GraphClient
    {
        private Uri uri;
        private string primaryKey;

        public GraphClient(Uri uri, string primaryKey)
        {
            this.uri = uri;
            this.primaryKey = primaryKey;
        }

        internal Task ConnectAsync()
        {
            throw new NotImplementedException();
        }
    }
}