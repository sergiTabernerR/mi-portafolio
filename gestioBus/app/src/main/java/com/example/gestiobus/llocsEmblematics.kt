package com.example.gestiobus

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.gestiobus.databinding.ActivityLlocsEmblematicsBinding
import com.example.gestiobus.databinding.ActivityMainBinding
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import java.lang.Exception

class llocsEmblematics : AppCompatActivity() {
    private lateinit var binding: ActivityLlocsEmblematicsBinding
    private lateinit var adaptadorLlocsEmblematic: AdaptadorLlocEmblematic
    private lateinit var idLinia:String
    private var InteresTuristics = mutableListOf<InteresTuristics>()
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityLlocsEmblematicsBinding.inflate(layoutInflater)
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
       idLinia =FitxaParada.idLinia
        var idParada = FitxaParada.idParada
        CoroutineScope(Dispatchers.IO).launch {
            val call = getRetrofit().create(ApiService::class.java).getLlocs("llocs/45")
            val llocs = call.body()
            runOnUiThread {
                try {
                    InteresTuristics = llocs as MutableList<InteresTuristics>
                    adaptadorLlocsEmblematic = AdaptadorLlocEmblematic(InteresTuristics)
                    binding.rvllocEmblematic.layoutManager = LinearLayoutManager(binding.rvllocEmblematic.context)
                    binding.rvllocEmblematic.adapter = adaptadorLlocsEmblematic

                }catch(e: Exception)
                {
                    Toast.makeText(this@llocsEmblematics,"No es poden conseguir les parades" + idLinia, Toast.LENGTH_SHORT).show()
                }

            }
        }
    }

    private fun initRecyclerViewParada() {
        adaptadorLlocsEmblematic = AdaptadorLlocEmblematic(InteresTuristics)
        binding.rvllocEmblematic.layoutManager = LinearLayoutManager(this)
        binding.rvllocEmblematic.adapter = adaptadorLlocsEmblematic
    }

    override fun onSupportNavigateUp(): Boolean {
        onBackPressed();
        return super.onSupportNavigateUp()
    }
}