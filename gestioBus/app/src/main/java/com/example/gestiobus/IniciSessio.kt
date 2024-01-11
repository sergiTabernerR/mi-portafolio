package com.example.gestiobus

import android.content.Intent
import android.graphics.Color
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.gestiobus.databinding.ActivityCrearCompteBinding
import com.example.gestiobus.databinding.ActivityIniciSessioBinding
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import java.lang.Exception

class IniciSessio : AppCompatActivity() {
    private lateinit var binding: ActivityIniciSessioBinding
    private var listUser = mutableListOf<User>()
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityIniciSessioBinding.inflate(layoutInflater)
        setContentView(binding.root)
        getUsers()
        var sha = sha()
        binding.Login.setOnClickListener {
            var usuari: String = binding.usuari.text.toString()
            var contraseña: String = binding.contraseA.text.toString()
            val intent = Intent(this, MainActivity::class.java)
            var calculatesha = sha.calculateSHA(usuari + contraseña)

            var userExist = existsUser(usuari)
            if(userExist!=null){
                if(calculatesha.equals(userExist.password)){
                    startActivity(intent)
                }
                else {
                    Toast.makeText(this@IniciSessio, "El Password no es correcte", Toast.LENGTH_SHORT)
                        .show()
                }
            }
            else {
                Toast.makeText(this@IniciSessio, "El Usuari no es correcte", Toast.LENGTH_SHORT)
                    .show()
            }
        }
        binding.crearCompte.setOnClickListener {
            val intent = Intent(this, crearCompte::class.java)
            startActivity(intent)
        }
    }
    // funcion auxiliar getUsers
    private fun existsUser(user:String): User? {
        for(u in listUser){
            if(u.userName.equals(user)){
                return u
            }
        }
        return null
    }


    private fun getRetrofit(): Retrofit {
        return Retrofit.Builder()
            .baseUrl("https://gestiobuswebservice.conveyor.cloud/api/GestioBus/")
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
                        this@IniciSessio,
                        "No se puede conseguir los usuarios",
                        Toast.LENGTH_SHORT
                    ).show()
                }

            }

        }
    }
}