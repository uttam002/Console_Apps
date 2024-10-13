namespace FlashcardApp.Models
{
    public class Flashcard
    {
        public string Question { get; private set; }
        public string Answer { get; private set; }
        public bool IsCorrect { get; set; }
        public string Category { get; set; }
        public List<string> Tags { get; set; }

        public Flashcard(string question, string answer, string category, List<string> tags = null)
        {
            Question = question;
            Answer = answer;
            IsCorrect = false;
            Category = category;
            Tags = tags ?? new List<string>();
        }

        public void MarkCorrect() => IsCorrect = true;
        public void MarkIncorrect() => IsCorrect = false;

        public override string ToString()
        {
            var tagStr = Tags.Count > 0 ? string.Join(", ", Tags) : "None";
            return $"Question: {Question}\nAnswer: {Answer}\nCategory: {Category}\nTags: {tagStr}";
        }
    }
}
