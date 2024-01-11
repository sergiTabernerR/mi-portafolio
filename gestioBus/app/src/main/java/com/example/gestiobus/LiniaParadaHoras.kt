package com.example.gestiobus

import com.google.gson.annotations.SerializedName

data class LiniaParadaHoras(
    @SerializedName("linia"        ) var linia        : Linia?  = Linia(),
    @SerializedName("parada"       ) var parada       : Parada? = Parada(),
    @SerializedName("id"           ) var id           : Int?    = null,
    @SerializedName("idParada"     ) var idParada     : Int?    = null,
    @SerializedName("idLinia"      ) var idLinia      : Int?    = null,
    @SerializedName("numeroParada" ) var numeroParada : Int?    = null
)
