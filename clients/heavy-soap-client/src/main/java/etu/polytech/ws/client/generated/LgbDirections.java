
package etu.polytech.ws.client.generated;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for LgbDirections complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="LgbDirections"&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="BikeDistance" type="{http://www.w3.org/2001/XMLSchema}double" minOccurs="0"/&gt;
 *         &lt;element name="BikeDuration" type="{http://www.w3.org/2001/XMLSchema}double" minOccurs="0"/&gt;
 *         &lt;element name="FootDistance" type="{http://www.w3.org/2001/XMLSchema}double" minOccurs="0"/&gt;
 *         &lt;element name="FootDuration" type="{http://www.w3.org/2001/XMLSchema}double" minOccurs="0"/&gt;
 *         &lt;element name="Steps" type="{http://schemas.datacontract.org/2004/07/routing_server.Implementation.Helper.open_route_objects}ArrayOfLgbStep" minOccurs="0"/&gt;
 *         &lt;element name="TotalDistance" type="{http://www.w3.org/2001/XMLSchema}double" minOccurs="0"/&gt;
 *         &lt;element name="TotalDuration" type="{http://www.w3.org/2001/XMLSchema}double" minOccurs="0"/&gt;
 *         &lt;element name="activemqQueueID" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "LgbDirections", propOrder = {
    "bikeDistance",
    "bikeDuration",
    "footDistance",
    "footDuration",
    "steps",
    "totalDistance",
    "totalDuration",
    "activemqQueueID"
})
public class LgbDirections {

    @XmlElement(name = "BikeDistance")
    protected Double bikeDistance;
    @XmlElement(name = "BikeDuration")
    protected Double bikeDuration;
    @XmlElement(name = "FootDistance")
    protected Double footDistance;
    @XmlElement(name = "FootDuration")
    protected Double footDuration;
    @XmlElementRef(name = "Steps", namespace = "http://schemas.datacontract.org/2004/07/routing_server.Implementation.Helper.open_route_objects", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfLgbStep> steps;
    @XmlElement(name = "TotalDistance")
    protected Double totalDistance;
    @XmlElement(name = "TotalDuration")
    protected Double totalDuration;
    @XmlElementRef(name = "activemqQueueID", namespace = "http://schemas.datacontract.org/2004/07/routing_server.Implementation.Helper.open_route_objects", type = JAXBElement.class, required = false)
    protected JAXBElement<String> activemqQueueID;

    /**
     * Gets the value of the bikeDistance property.
     * 
     * @return
     *     possible object is
     *     {@link Double }
     *     
     */
    public Double getBikeDistance() {
        return bikeDistance;
    }

    /**
     * Sets the value of the bikeDistance property.
     * 
     * @param value
     *     allowed object is
     *     {@link Double }
     *     
     */
    public void setBikeDistance(Double value) {
        this.bikeDistance = value;
    }

    /**
     * Gets the value of the bikeDuration property.
     * 
     * @return
     *     possible object is
     *     {@link Double }
     *     
     */
    public Double getBikeDuration() {
        return bikeDuration;
    }

    /**
     * Sets the value of the bikeDuration property.
     * 
     * @param value
     *     allowed object is
     *     {@link Double }
     *     
     */
    public void setBikeDuration(Double value) {
        this.bikeDuration = value;
    }

    /**
     * Gets the value of the footDistance property.
     * 
     * @return
     *     possible object is
     *     {@link Double }
     *     
     */
    public Double getFootDistance() {
        return footDistance;
    }

    /**
     * Sets the value of the footDistance property.
     * 
     * @param value
     *     allowed object is
     *     {@link Double }
     *     
     */
    public void setFootDistance(Double value) {
        this.footDistance = value;
    }

    /**
     * Gets the value of the footDuration property.
     * 
     * @return
     *     possible object is
     *     {@link Double }
     *     
     */
    public Double getFootDuration() {
        return footDuration;
    }

    /**
     * Sets the value of the footDuration property.
     * 
     * @param value
     *     allowed object is
     *     {@link Double }
     *     
     */
    public void setFootDuration(Double value) {
        this.footDuration = value;
    }

    /**
     * Gets the value of the steps property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfLgbStep }{@code >}
     *     
     */
    public JAXBElement<ArrayOfLgbStep> getSteps() {
        return steps;
    }

    /**
     * Sets the value of the steps property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfLgbStep }{@code >}
     *     
     */
    public void setSteps(JAXBElement<ArrayOfLgbStep> value) {
        this.steps = value;
    }

    /**
     * Gets the value of the totalDistance property.
     * 
     * @return
     *     possible object is
     *     {@link Double }
     *     
     */
    public Double getTotalDistance() {
        return totalDistance;
    }

    /**
     * Sets the value of the totalDistance property.
     * 
     * @param value
     *     allowed object is
     *     {@link Double }
     *     
     */
    public void setTotalDistance(Double value) {
        this.totalDistance = value;
    }

    /**
     * Gets the value of the totalDuration property.
     * 
     * @return
     *     possible object is
     *     {@link Double }
     *     
     */
    public Double getTotalDuration() {
        return totalDuration;
    }

    /**
     * Sets the value of the totalDuration property.
     * 
     * @param value
     *     allowed object is
     *     {@link Double }
     *     
     */
    public void setTotalDuration(Double value) {
        this.totalDuration = value;
    }

    /**
     * Gets the value of the activemqQueueID property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getActivemqQueueID() {
        return activemqQueueID;
    }

    /**
     * Sets the value of the activemqQueueID property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setActivemqQueueID(JAXBElement<String> value) {
        this.activemqQueueID = value;
    }

}
