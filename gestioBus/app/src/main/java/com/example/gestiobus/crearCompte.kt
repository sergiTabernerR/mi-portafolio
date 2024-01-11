package com.example.gestiobus

import android.content.Intent
import android.os.Bundle
import android.view.View
import android.widget.*
import androidx.appcompat.app.AppCompatActivity
import com.example.gestiobus.databinding.ActivityCrearCompteBinding
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import java.lang.Exception


class crearCompte : AppCompatActivity() {
    private lateinit var binding: ActivityCrearCompteBinding
    private var listUser = mutableListOf<User>()
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityCrearCompteBinding.inflate(layoutInflater)
        setContentView(binding.root)
        var sha = sha()
        binding.darrera.setOnClickListener {
            val intent = Intent(this, IniciSessio::class.java)
            startActivity(intent)
        }
        binding.crearCompte.setOnClickListener {
            val intent = Intent(this, IniciSessio::class.java)
            var usuari:String = binding.usuari.text.toString()
            var contraseña:String = binding.contrasenya.text.toString()
            var confirmar:String = binding.confirmarContrasenya.text.toString()


            if(contraseña.equals(confirmar)){
               var calculatesha = sha.calculateSHA(usuari + contraseña)
                postData(usuari, calculatesha)
                getUsers()
                startActivity(intent)
            }
            else {
             Toast.makeText(this, "La Contraseña no coincideix", Toast.LENGTH_LONG).show()
            }


        }
    }



    private fun getRetrofit(): Retrofit {
        return Retrofit.Builder().baseUrl("https://gestiobuswebservice.conveyor.cloud/api/GestioBus/")
            .addConverterFactory(GsonConverterFactory.create()).build()

    }

    private fun getUsers() {
        CoroutineScope(Dispatchers.IO).launch {
            val call = getRetrofit().create(ApiService::class.java).getUsers("users")
            val user = call.body()
            runOnUiThread {
                try {
                    listUser = user as MutableList<User>

                } catch (e: Exception) {
                    Toast.makeText(
                        this@crearCompte,
                        "No es pot aconseguir els usuaris",
                        Toast.LENGTH_SHORT
                    ).show()
                }

            }
        }
    }
    private fun postData(usuari: String, contraseña: String) {
        // below line is for displaying our progress bar.
        binding.idLoadingPB.setVisibility(View.VISIBLE)

        val retrofitAPI: ApiService = getRetrofit().create(ApiService::class.java)

        // passing data from our text fields to our modal class.
        val modal = User(usuari, contraseña)

        // calling a method to create a post and passing our modal class.
        val call: Call<User> = retrofitAPI.addUser(modal)

        // on below line we are executing our method.
        call.enqueue(object : Callback<User> {
            override fun onResponse(call: Call<User>, response: Response<User>) {
                // this method is called when we get response from our api.
                Toast.makeText(this@crearCompte, "Usuari Creat", Toast.LENGTH_SHORT).show()

                binding.idLoadingPB.setVisibility(View.GONE)

                binding.usuari.setText("")
                binding.contrasenya.setText("")
                binding.confirmarContrasenya.setText("")


            }
            override fun onFailure(call: Call<User>, t: Throwable) {
                Toast.makeText(this@crearCompte, t.message, Toast.LENGTH_LONG).show()
            }
        })
    }
}