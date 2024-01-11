package com.example.gestiobus

import android.R
import android.os.Bundle
import android.os.Looper
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.gestiobus.databinding.ActivityMainBinding
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import java.io.InputStream
import java.security.cert.Certificate
import java.security.cert.CertificateFactory


class MainActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding
    private lateinit var adaptadorLinies: AdaptadorLinies
    private var Linia = mutableListOf<Linia>()

    companion object {

        const val REQUEST_CODE_lOCATION = 0
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)
        initRecyclerViewLinia()
        getLinies()
    }


    private fun getRetrofit(): Retrofit {
           return Retrofit.Builder().baseUrl("https://gestiobuswebservice.conveyor.cloud/api/GestioBus/")
            .addConverterFactory(GsonConverterFactory.create()).build()

    }

    private fun getLinies() {
        CoroutineScope(Dispatchers.IO).launch {
            try{
            val call = getRetrofit().create(ApiService::class.java).getLinies("linies")
                val linia = call.body()
                runOnUiThread {
                Linia = linia as MutableList<Linia>
                adaptadorLinies = AdaptadorLinies(Linia)
                binding.rv1.layoutManager = LinearLayoutManager(binding.rv1.context)
                binding.rv1.adapter = adaptadorLinies
                }
            }catch (e: Exception){
                Looper.prepare();
                Toast.makeText(this@MainActivity, "No es pot connectar al servidor", Toast.LENGTH_LONG).show();
                Looper.loop();
            }
        }
    }
    private fun initRecyclerViewLinia() {
        adaptadorLinies = AdaptadorLinies(Linia)
        binding.rv1.layoutManager = LinearLayoutManager(this)
        binding.rv1.adapter = adaptadorLinies
    }


}



