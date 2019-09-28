#include <iostream>
using namespace std;

struct Nodo
{
public:
    int dato;
    Nodo *derecha;
    Nodo *izquierda;
    Nodo(int dato)
    {
        this->dato = dato;
        this->derecha = NULL;
        this->izquierda = NULL;
    }
};

typedef Nodo *nodo;

struct Arbolbinario
{
public:
    nodo raiz;
    Arbolbinario()
    {
        this->raiz = NULL;
    }
    void insertar(int dato);
    nodo insertar(nodo actual, nodo nuevo);
    void preorden();
    void preorden(nodo actual);
    void eliminar(int dato);
    nodo eliminar(nodo actual, int dato);
};

void Arbolbinario::insertar(int dato)
{
    nodo nuevo = new Nodo(dato);
    raiz = insertar(raiz, nuevo);
}

nodo Arbolbinario::insertar(nodo actual, nodo nuevo)
{
    if (actual == NULL)
        return nuevo;
    if (nuevo->dato < actual->dato)
        actual->izquierda = insertar(actual->izquierda, nuevo);
    else
        actual->derecha = insertar(actual->derecha, nuevo);
    return actual;
}

void Arbolbinario::preorden()
{
    if (raiz != NULL)
        preorden(raiz);
}

void Arbolbinario::preorden(nodo actual)
{
    if (actual != NULL)
    {
        cout << actual->dato << " , ";
        preorden(actual->izquierda);
        preorden(actual->derecha);
    }
}

void Arbolbinario::eliminar(int dato)
{
    if (raiz != NULL)
        raiz = eliminar(raiz, dato);
}

nodo Arbolbinario::eliminar(nodo actual, int dato)
{
    if (actual != NULL)
    {
        if (actual->dato == dato)
        {
            nodo aux1 = actual->izquierda;
            nodo aux2 = aux1;
            if (aux1 != NULL)
            {
                while (aux2->derecha != NULL)
                {
                    aux1 = aux2;
                    aux2 = aux2->derecha;
                }
                aux1->derecha = aux2->izquierda;
                if (aux1 != aux2)
                    aux2->izquierda = actual->izquierda;
                aux2->derecha = actual->derecha;

                actual = aux2;
            }
            else
            {
                actual = actual->derecha;
            }
            return actual;
        }
        if (actual->dato > dato)
            actual->izquierda = eliminar(actual->izquierda, dato);
        else
            actual->derecha = eliminar(actual->derecha, dato);
    }

    return actual;
}

typedef Arbolbinario *arbolbinario;

void menu()
{
    cout << "Presiona : \n";
    cout << "1.- insertar nodo al arbol \n";
    cout << "2.- eliminar nodo del arbol \n";
    cout << "3.- mostrar en preorden \n";
    cout << "4.- salir \n";
}

int main()
{
    arbolbinario a = new Arbolbinario();
    int numero = 0;
    while (numero != 4)
    {
        menu();
        cin >> numero;
        if (numero == 1)
        {
            cout << "dame el valor del nodo\n";
            int valor;
            cin >> valor;
            a->insertar(valor);
        }
        else if (numero == 2)
        {
            cout << "dame el valor del nodo\n";
            int valor;
            cin >> valor;
            a->eliminar(valor);
        }
        else if (numero == 3)
        {
            cout << "arbol binario : ";
            a->preorden();
            cout << '\n';
        }
    }
    system("PAUSE");
    return 0;
}
