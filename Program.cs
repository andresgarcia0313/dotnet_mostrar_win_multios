using Avalonia; // Importa la biblioteca Avalonia para la interfaz gráfica
using Avalonia.Controls; // Importa controles gráficos como ventanas y botones
using Avalonia.Controls.ApplicationLifetimes; // Maneja el ciclo de vida de la aplicación
using Avalonia.Markup.Xaml; // Permite cargar interfaces desde archivos XAML

namespace MostrarWindotnet; // Define el espacio de nombres del programa

// Clase principal del programa
static class Program
{
    // Método principal que inicia la aplicación
    public static void Main(string[] args) => BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    
    // Método que configura y construye la aplicación Avalonia
    private static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>().UsePlatformDetect().LogToTrace();
}

// Clase que representa la aplicación
public class App : Application
{
    // Método que inicializa la interfaz de usuario desde un archivo XAML
    public override void Initialize() => AvaloniaXamlLoader.Load(this);
    
    // Método que se ejecuta cuando la aplicación ha terminado de inicializarse
    public override void OnFrameworkInitializationCompleted()
    {
        // Verifica si la aplicación se ejecuta en un entorno de escritorio
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            // Define la ventana principal de la aplicación
            desktop.MainWindow = new MainWindow();
        
        base.OnFrameworkInitializationCompleted(); // Llama a la implementación base
    }
}

// Clase que representa la ventana principal
public class MainWindow : Window
{
    // Constructor de la ventana
    public MainWindow()
    {
        Title = "Programa"; // Título de la ventana
        Width = 400; // Ancho de la ventana en píxeles
        Height = 300; // Alto de la ventana en píxeles
        Content = UI(); // Asigna el contenido de la ventana llamando al método UI
    }
    
    // Método que define el contenido de la ventana
    private static Control UI() => new TextBlock
    {
        Text = "Texto", // Texto que se mostrará en la ventana
        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center, // Centra el texto horizontalmente
        VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center // Centra el texto verticalmente
    };
}
