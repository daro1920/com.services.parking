/**
 * plate_reader-1.1 7/9/2014
 * Rubens Barrios
 * 
 * 
 * This class is meant to get and recognize the character
 * in a car's plate image.
 */
package com.plate.reader;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map.Entry;

import javax.imageio.ImageIO;

import net.coobird.thumbnailator.Thumbnails;

import org.neuroph.core.NeuralNetwork;
import org.neuroph.imgrec.ImageRecognitionPlugin;

public class ImgController {

	public StringBuffer getCharFromPlate(String dir)  {
		
		ImgController imtc = new ImgController();
		String pic  = dir+"\\matricula.jpg";
		StringBuffer result =new StringBuffer();
		
		
		
	    String letter = null;
	    String number = null;
	    
		try {
			
			BufferedImage plate = ImageIO.read(new File(pic));
			
			// crop image and save the result in a static directory.
			imtc.getCropImages(plate,dir);
			for (int i = 1; i<=3; i ++){
				File image = new File(dir+"\\lett"+i+".jpg");
				letter = imtc.getLettFromImage(image);
				result.append(letter);
			}
			for (int i = 1; i<=4; i ++){
				File image = new File(dir+"\\num"+i+".jpg");
				number = imtc.getNumFromImage(image);
				result.append(number);
			}
			
			
		} catch (IOException e) {
			result.append("No existe matricula.jpg en el directorio dado");
		}
		return result;
		

	}
	public void getCropImages(BufferedImage plate,String dir) throws IOException {
		
		//plate= Thumbnails.of(plate).forceSize(84,247);
		// get image , get pixels(height and width), crop chars, save images
		int oriWidth = plate.getWidth();
		int oriHeight = plate.getHeight();

		int x = Math.round((5f * oriWidth) / 90.0f);
		int y = Math.round((15f * oriHeight) / 100.0f);
		//System.out.println(x);
		BufferedImage subPlate = plate.getSubimage(x, y, oriWidth - x,oriHeight -y*3);// x,y,w,h
		
		//It saves into a directories the plate's letters and numbers 
		cropLettersAndNumbersFromPlate(subPlate,dir);
		
		
	}

	private void cropLettersAndNumbersFromPlate(BufferedImage subPlate,String dir) throws IOException {
		// TODO Auto-generated method stub
		
		BufferedImage plateLett = null;
		BufferedImage plateNum = null;
		File outputfile = null;
		
		//getting letters from sub-plate
		int lettWidth  = Math.round((subPlate.getWidth())/7.6f);
		int lettHeight = subPlate.getHeight();
		
		int i = 0;
		for(int j = 1; j < 4; j++){
			plateLett = (BufferedImage) subPlate.getSubimage(i, 0,lettWidth ,lettHeight);// x,y,w,h
			outputfile = new File(dir+"\\lett"+j+".jpg");
			ImageIO.write(Thumbnails.of(plateLett).forceSize(66, 100).asBufferedImage(), "jpg", outputfile);
			i= i+lettWidth;
		}//(100*lettWidth)/lettHeight
		//taking subplate after the gap
		int x = Math.round((subPlate.getWidth())/2.1f);
		subPlate = subPlate.getSubimage(x, 0,subPlate.getWidth() -x,lettHeight);
		
		// getting numbers from sub-plate
		int numWidth  = Math.round((subPlate.getWidth())/4.5f);
		int numHeight = subPlate.getHeight();
		
		i = 0;
		for(int j = 1; j < 5; j++){
			plateNum = subPlate.getSubimage(i, 0,numWidth ,numHeight);// x,y,w,h
			outputfile = new File(dir+"\\num"+j+".jpg");
			ImageIO.write(Thumbnails.of(plateNum).forceSize((100*lettWidth)/lettHeight, 100).asBufferedImage(), "jpg", outputfile);
			i=i+numWidth;
		}
//		return subPlate;
		
	}


	@SuppressWarnings("rawtypes")
	public String getLettFromImage(File letter) throws IOException {
		// load trained neural network saved with Neuroph Studio (specify some existing neural network file here)
		NeuralNetwork nnet = null;
		Entry<String, Double> matchChar = null;
		
		for (int i = 1; i<=5; i++){
			nnet = NeuralNetwork.createFromFile("C:\\TrainingImages\\Lett_Group\\Neural Networks\\lett_group"+i+"_net.nnet");
			
			// get the image recognition plugin from neural network
			ImageRecognitionPlugin imageRecognition = (ImageRecognitionPlugin) nnet.getPlugin(ImageRecognitionPlugin.class); 
			HashMap<String, Double> output = null;

			
			try {
				// image recognition is done here (specify some existing image file)
				output = imageRecognition.recognizeImage(letter);
				
				for (Entry<String, Double> entry : output.entrySet()) {
					//System.out.println("Letra: "+entry.getKey()+" Valor: "+entry.getValue());
					if (matchChar == null || entry.getValue() > matchChar.getValue()) {
						
						matchChar = entry;
						
					}
				}
				//System.out.println();

			} catch (IOException ioe) {
				ioe.printStackTrace();
			}
		}

		
		return matchChar.getKey();
	}
	
	
	@SuppressWarnings("rawtypes")
	public String getNumFromImage(File letter) throws IOException {
		// load trained neural network saved with Neuroph Studio (specify some existing neural network file here)
		NeuralNetwork nnet = null;
		Entry<String, Double> matchChar = null;
		
		for (int i = 1; i<=2; i++){
			nnet = NeuralNetwork.createFromFile("C:\\TrainingImages\\Num_Group\\Neural Networks\\num_group"+i+"_net.nnet");
			
			// get the image recognition plugin from neural network
			ImageRecognitionPlugin imageRecognition = (ImageRecognitionPlugin) nnet.getPlugin(ImageRecognitionPlugin.class); 
			HashMap<String, Double> output = null;

			
			try {
				// image recognition is done here (specify some existing image file)
				output = imageRecognition.recognizeImage(letter);
				
				for (Entry<String, Double> entry : output.entrySet()) {
					//System.out.println("Letra: "+entry.getKey()+" Valor: "+entry.getValue());
					if (matchChar == null || entry.getValue() > matchChar.getValue()) {
						
						matchChar = entry;
						
					}
				}
				//System.out.println();

			} catch (IOException ioe) {
				ioe.printStackTrace();
			}
		}

		
		return matchChar.getKey();
	}

}
