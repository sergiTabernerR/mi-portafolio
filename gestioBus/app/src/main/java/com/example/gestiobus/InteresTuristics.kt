package com.example.gestiobus

import com.google.gson.annotations.SerializedName

data class InteresTuristics(

    @SerializedName("parada"   ) var parada   : Parada? = Parada(),
    @SerializedName("id"       ) var id       : Int?    = null,
    @SerializedName("nom"      ) var nom      : String? = null,
    @SerializedName("urlImg"   ) var urlImg   : String? = null,
    @SerializedName("urlWeb"   ) var urlWeb   : String? = null,
    @SerializedName("direccio" ) var direccio : String? = null,
    @SerializedName("idParada" ) var idParada : Int?    = null
)
