package com.example.gestiobus

import com.google.gson.annotations.SerializedName

data class Horaris(
    @SerializedName("parada"          ) var parada          : Parada? = Parada(),
    @SerializedName("linia"           ) var linia           : Linia?  = Linia(),
    @SerializedName("id"              ) var id              : Int?    = null,
    @SerializedName("idParada"        ) var idParada        : Int?    = null,
    @SerializedName("idLinia"         ) var idLinia         : Int?    = null,
    @SerializedName("hora"            ) var hora            : String? = null,
    @SerializedName("direccio"        ) var direccio        : Int?    = null,
    @SerializedName("tipus"           ) var tipus           : Int?    = null,
    @SerializedName("dataIniciVigent" ) var dataIniciVigent : String? = null,
    @SerializedName("dataFinalVigent" ) var dataFinalVigent : String? = null
)
