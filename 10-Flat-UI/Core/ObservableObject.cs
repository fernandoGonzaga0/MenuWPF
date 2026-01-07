using System;
using System.ComponentModel;
using System.Runtime.CompilerServices; // permite usar o atributo CallerMemberName, que captura automaticamente o nome da propriedade que chamou o método

/*
No WPF, existe o conceito de data binding (ligação de dados). Isso significa que podemos ligar propriedades de objetos (ViewModel) diretamente a elementos da interface (UI).
Para que a UI seja atualizada automaticamente quando o valor de uma propriedade muda, o objeto precisa notificar a interface sobre essa mudança. Para isso, usamos a interface
INotifyPropertyChanged.
*/

namespace _10_Flat_UI.Core
{
    // classe implementando a interface INofityPropertyChanged
    internal class ObservableObject : INotifyPropertyChanged
    {
        // o evento abaixo é exigido pela interface, ele é disparado sempre que uma propriedade mudar, avisando a UI que precisa se atualizar
        public event PropertyChangedEventHandler PropertyChanged;

        // método para disparar o evento, onde ao chamá-lo dentro de uma propriedade, o compilador passa o nome da propriedade que chamou automaticamente por causa do CallerMemberName
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            /*
            PropertyChanged?: verifica se alguém está inscrito no evento (se não for null).
            .Invoke(...): dispara o evento.
            new PropertyChangedEventArgs(name): cria o argumento do evento, informando qual propriedade mudou. 
            */
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}