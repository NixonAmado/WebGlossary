namespace API.Dtos;

public class G_WordDto
{
    public int Id { get; set; }

    public string Word { get; set; }

    public bool Plural { get; set; }

    public virtual string VerbalTense { get; set; }

    public virtual string WordType { get; set; }

    public string Translation { get; set; }


}
