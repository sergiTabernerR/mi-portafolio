package com.example.gestiobus

import com.google.gson.annotations.SerializedName

 class Geography(){

     @SerializedName("coordinateSystemId" ) var coordinateSystemId : Int?    = null
     @SerializedName("wellKnownText"      ) var wellKnownText      : String? = null
     lateinit var parsewkt: List<String>

     var long: Double = 0.0
     var lat: Double = 0.0

     companion object {
        fun parseWKT(geo: Geography?){
         if(geo!!.wellKnownText !=null)
         {
             geo.parsewkt = geo.wellKnownText.toString().split("POINT (").toString().
             replace(")"," ").split(" ")
             geo.lat = geo.parsewkt[1].toDouble()
             geo.long = geo.parsewkt[2].toDouble()

         }

        }

     }

 }





