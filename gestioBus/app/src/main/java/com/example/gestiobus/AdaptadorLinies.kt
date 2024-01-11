package com.example.gestiobus

import android.content.Intent
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.gestiobus.databinding.CardViewLiniaBinding
import com.example.gestiobus.databinding.CardViewParadaBinding

class AdaptadorLinies(val llista: List<Linia>): RecyclerView.Adapter<AdaptadorLinies.ViewHolder>() {
    class ViewHolder(vista:View): RecyclerView.ViewHolder(vista) {
        val nomLinia: TextView
        val descripcio:TextView

        private val binding = CardViewLiniaBinding.bind(vista)

        init {
            nomLinia = binding.linia
            descripcio = binding.descripcio
        }

    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): AdaptadorLinies.ViewHolder {
        val layout= LayoutInflater.from(parent.context)
        return ViewHolder(layout.inflate(R.layout.card_view_linia, parent, false))
    }

    override fun onBindViewHolder(holder: AdaptadorLinies.ViewHolder, position: Int) {
        holder.itemView.setOnClickListener {
            val intent = Intent(holder.itemView.context, FitxaParada::class.java)
            intent.putExtra("idLinia", llista[position].idLinia.toString())
            intent.putExtra("linia", llista[position].nom)
            intent.putExtra("descripcio", llista[position].descripcio)

            holder.itemView.context.startActivity(intent)
        }
        holder.nomLinia.text = llista[position].nom
        holder.descripcio.text = llista[position].descripcio

    }

    override fun getItemCount(): Int {
        return llista.size
    }
}