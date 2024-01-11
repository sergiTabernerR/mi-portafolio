package com.example.gestiobus

import retrofit2.Call
import retrofit2.Response
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.Url


interface ApiService {

    @GET
    suspend fun getLinies(@Url url: String): Response<List<Linia>>
    @GET
    suspend fun getParada(@Url url: String): Response<List<Parada>>
    @GET
    suspend fun getLlocs(@Url url: String): Response<List<InteresTuristics>>
    @GET
    suspend fun getHorari(@Url url: String): Response<List<String>>
    @POST("users")
     fun addUser(@Body dataModal: User?): Call<User>
    @GET
    suspend fun getUsers(@Url url: String): Response<List<User>>

}