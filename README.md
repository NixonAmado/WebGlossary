# WebGlossary
El mundo de las TI es muy grande y muy útil, cuando tienes una idea tecnologica no tienes el conocimiento para hacerla realidad, pero lo que no sabes lo aprendes, así que, en este repositorio se ha creado una pagina web que es capaz de almacenar palabras en ingles para que después las practiques


1.Descargar el paquete OpenAi en API

2. definir la clave de open ia y la url en appsettings.json
  "OpenAi" :{
    "ApiUrl" : "https://api.openai.com/v1/engines/davinci/completions",
    "ApiKey" : "Sin implementar"
  }

3.Crear el helper que almacene las claves y valores del archivo Json
  namespace API.Helpers;
  public class OpenAi
  {
    public string ApiUrl {get;set;}
    public string ApiKey {get;set;}
  }

4.Crear la extension de conexion con el paso Nro 2 en applicationServiceExtension
    public static void AddOpenAi(this IServiceCollection services, IConfiguration configuration)
    {
        // custom service configuration  using 'OpenAiOptions'...
        services.Configure<OpenAi>(configuration.GetSection("OpenAiOptions"));
    }
  - Conectar con la inyeccion de dependencias
	builder.Services.AddOpenAi(builder.Configuration); //Aplicacion de OpenAi

5.Crear un microservicio para el uso de openAi, siguiendo los principios solid y según el enfoque que se quiera realizar 
implementarlo junto a las interfaces, en mi caso uso  Principio de Responsabilidad Única (SRP) para establecer un enfoque 
unitario entre la interfaz y su implementacion
namespace API.Services
{
    public interface IOpenAIService
    {
        public string DetermineWordFeatures(string word);
        public string DeterminePhaseFeatures (string phase);
    }
}