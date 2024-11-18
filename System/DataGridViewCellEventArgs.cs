





namespace System
{
    internal class DataGridViewCellEventArgs
    {
        private Action<object, Windows.Forms.DataGridViewCellEventArgs> dataGridView1_Click;
        private Action<object, DataGridViewCellEventArgs> dataGridView1_Click1;

        public DataGridViewCellEventArgs(Action<object, Windows.Forms.DataGridViewCellEventArgs> dataGridView1_Click)
        {
            this.dataGridView1_Click = dataGridView1_Click;
        }

        public DataGridViewCellEventArgs(Action<object, DataGridViewCellEventArgs> dataGridView1_Click1)
        {
            this.dataGridView1_Click1 = dataGridView1_Click1;
        }

        public int RowIndex { get; internal set; }
    }
}