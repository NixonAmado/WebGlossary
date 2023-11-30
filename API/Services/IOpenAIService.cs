// Microservice for learning about how implement artificial inteligence in my projects.
// With artificial inteligence i want to manage the features of a word or phase,   the 
// main idea is that this microSevice receive an input  (word or phase)  and determine 
// his features, for example it receive a word:thoroughly, the ai will be  responsible
// to define if the word is an adverb(wordType), if it's plural(plural: T,F) and if it
// has verbaltense will tell the tense it is in.

using API.Dtos;

namespace API.Services
{
    public interface IOpenAIService
    {
        public Task<string> DetermineWordFeatures(WordDto word);
        //public string DeterminePhaseFeatures (string phase);
    }
}