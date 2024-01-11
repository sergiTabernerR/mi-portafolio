package com.example.gestiobus

import com.google.gson.annotations.Expose
import com.google.gson.annotations.SerializedName

data class User(


    @Expose(serialize = false)
    @SerializedName("userName") var userName: String? = null,
    @Expose(serialize = false)
    @SerializedName("password") var password: String? = null,
)



