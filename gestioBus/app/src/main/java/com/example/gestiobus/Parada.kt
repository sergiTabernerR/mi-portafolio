package com.example.gestiobus

import com.google.gson.annotations.SerializedName

class Parada {

    @SerializedName("horaris"          ) var horaris          : ArrayList<Horaris> = arrayListOf()
    @SerializedName("interesTuristics" ) var interesTuristics : ArrayList<InteresTuristics> = arrayListOf()
    @SerializedName("liniaParadaHoras" ) var liniaParadaHoras : ArrayList<LiniaParadaHoras> = arrayListOf()
    @SerializedName("id"               ) var idParada         : Int?                        = null
    @SerializedName("coord"            ) var coord            : Coord?                      = Coord()
    @SerializedName("nom"              ) var nomParada        : String?                     = null
}