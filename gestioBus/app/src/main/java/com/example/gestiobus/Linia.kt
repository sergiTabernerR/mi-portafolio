package com.example.gestiobus

import com.google.gson.annotations.SerializedName

data class Linia(

    @SerializedName("conductors"       ) var conductors       : ArrayList<String>           = arrayListOf(),
    @SerializedName("horaris"          ) var horaris          : ArrayList<Horaris>          = arrayListOf(),
    @SerializedName("liniaParadaHoras" ) var liniaParadaHoras : ArrayList<LiniaParadaHoras> = arrayListOf(),
    @SerializedName("transports"       ) var transports       : ArrayList<String>           = arrayListOf(),
    @SerializedName("id"               ) var idLinia               : Int?                        = null,
    @SerializedName("nom"              ) var nom              : String?                     = null,
    @SerializedName("descripcio"       ) var descripcio       : String?                     = null
)

