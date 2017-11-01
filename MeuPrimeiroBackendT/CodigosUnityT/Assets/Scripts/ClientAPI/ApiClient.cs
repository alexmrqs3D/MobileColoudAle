﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ApiClient : MonoBehaviour
{
    const string url = "http://localhost:50287/API/Items/";

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetItensAPI());
    }

    IEnumerator GetItensAPI()
    {
        //UnityWebRequest request = UnityWebRequest.Get(url + "/1");
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.Send();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string strRespostaServidor = request.downloadHandler.text;
            Debug.Log(strRespostaServidor);

            byte[] result = request.downloadHandler.data;

            //Item meuItem = JsonUtility.FromJson<Item>(strRespostaServidor);
            //ImprimirItem(meuItem);

            //*ListaItens listaItensServidor = new ListaItens();
            //*JsonUtility.FromJsonOverwrite(strRespostaServidor, listaItensServidor);

            Item[] teste = JsonHelper.getJsonArray<Item>(strRespostaServidor);

            Text texto = GetComponent<Text>();

            ImprimirItemHUD(teste[0], texto);

            foreach (Item i in teste)
            {
                ImprimirItem(i);
            }
        }
    }

    void ImprimirItem(Item i)
    {
        Debug.Log("====== Dados objeto ======= ");
        Debug.Log("ID: " + i.ItemID);
        Debug.Log("Nome: " + i.Nome);
        Debug.Log("Altura: " + i.Altura);
        Debug.Log("Forca: " + i.Forca);
        Debug.Log("Inteligencia: " + i.Inteligencia);

    }

    void ImprimirItemHUD(Item i, Text texto)
    {
        texto.text += "====== Dados objeto =======";
        texto.text += "ID: " + i.ItemID;
        texto.text += "Nome: " + i.Nome;
        texto.text += "Altura: " + i.Altura;
        texto.text += "Forca: " + i.Forca;
        texto.text += "Inteligencia: " + i.Inteligencia;

    }
}
