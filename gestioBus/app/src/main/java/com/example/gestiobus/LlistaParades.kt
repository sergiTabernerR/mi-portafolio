package com.example.gestiobus

import android.content.Intent
import android.icu.number.IntegerWidth
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.gestiobus.databinding.ActivityMainBinding
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import java.lang.Exception

class LlistaParades : AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding
    private lateinit var adaptadorParades: AdaptadorParades
    private lateinit var idLinia:String
    private var Parada = mutableListOf<Parada>()
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)
        initRecyclerViewParada()
        getParades()

    }

    private fun getRetrofit(): Retrofit {

        return Retrofit.Builder()
            .baseUrl("https://gestiobuswebservice.conveyor.cloud/api/GestioBus/")
            .addConverterFactory(GsonConverterFactory.create()).build()

    }

    private fun getParades() {
        CoroutineScope(Dispatchers.IO).launch {
            val call = getRetrofit().create(ApiService::class.java).getParada("parades/$idLinia")
            val parada = call.body()
            runOnUiThread {
                try {
                    Parada = parada as MutableList<Parada>
                    adaptadorParades = AdaptadorParades(Parada)
                    binding.rv1.layoutManager = LinearLayoutManager(binding.rv1.context)
                    binding.rv1.adapter = adaptadorParades

                }catch(e: Exception)
                {
                    Toast.makeText(this@LlistaParades,"No es poden conseguir les parades" + idLinia, Toast.LENGTH_SHORT).show()
                }
            }
        }
    }

    private fun initRecyclerViewParada() {
        adaptadorParades = AdaptadorParades(Parada)
        binding.rv1.layoutManager = LinearLayoutManager(this)
        binding.rv1.adapter = adaptadorParades
    }

    override fun onSupportNavigateUp(): Boolean {
        onBackPressed();
        return super.onSupportNavigateUp()
    }
}